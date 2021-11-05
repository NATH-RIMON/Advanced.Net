using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models.VM;
using System.ComponentModel.DataAnnotations;
using Project.Models.Entities;
using Project.Service;
using Project.Auth;

namespace Project.Service
{
    public class SMSProcess
    {
        public void InsertMessage(Message m)
        {
            var db = new ProjectEntities();
            db.Messages.Add(m);
            db.SaveChanges();
        }
        public int Process(int userId, SenderModel um)
        {
            SMSSender sms = new SMSSender();
            SMSLength smsLength = new SMSLength();
            Message messageModel = new Message();
            smsLength.count(um.Message.Trim());
            var db = new ProjectEntities();
            var usersData = (from c in db.Users where c.Id == userId select c).FirstOrDefault();
            double balance = usersData.Balance;

            double charge = 0.40 * smsLength.Count;


            // System.Diagnostics.Debug.WriteLine(smsLength.Count);

            if (balance >= charge)
            {
                string numberText = um.Numbers.Trim().Replace("+88", String.Empty);
                string msgText = um.Message.Trim();

                var senderNumbersData = (from c in db.SenderNumbers where c.Id == um.SenderNumberId select c).FirstOrDefault();
                sms.ApiToken = senderNumbersData.ApiToken.ToString().Trim();
                sms.DeviceId = senderNumbersData.DeviceId.ToString().Trim();
                sms.Numbers = numberText;
                sms.Message = msgText;

                messageModel.UserId = userId;
                messageModel.MessageBody = msgText;
                messageModel.Numbers = numberText;
                messageModel.SendTime = DateTime.Now.ToString();



                if (sms.Send())
                {

                    double currentBalance = usersData.Balance - charge;
                    User u = new User()
                    {

                        Id = usersData.Id,
                        Name = usersData.Name,
                        Email = usersData.Email,
                        Password = usersData.Password,
                        Balance = currentBalance,
                        Role = usersData.Role,
                        RegTime = usersData.RegTime

                    };
                    var data = (from c in db.Users where c.Id == userId select c).FirstOrDefault();
                    db.Entry(data).CurrentValues.SetValues(u);
                    db.SaveChanges();
                    messageModel.Status = "Success";
                    this.InsertMessage(messageModel);
                    //ViewBag.SuccessMessage = "Message Send";
                    //return RedirectToAction("Home\Index");
                    return 1;

                }
                else
                {
                    messageModel.Status = "Failed";
                    this.InsertMessage(messageModel);
                    return 2;
                }


            }
            else
            {
                return 3;
            }

        }
    }
}