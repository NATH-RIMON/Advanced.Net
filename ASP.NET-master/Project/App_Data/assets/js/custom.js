function loadpage(url) {
    window.location = url;
}






scrollingElement = (document.scrollingElement || document.body)
function scrollSmoothToBottom (id) {
   $(scrollingElement).animate({
      scrollTop: document.body.scrollHeight
   }, 500);
}



function fetchTemplate(Id) {
    var http = new XMLHttpRequest();
    http.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("messageInput").innerHTML = this.responseText;
			
        }
    };
    var url = "/Template/Fetch/" + Id + "";
	
    http.open("POST", url, true);
    http.send();
}



   

    $(function () {
              
        let messageInput = $('#messageInput');
        

        function countMessage(input) {
            let counter = input.data('counter');
            if (input.val()) {
                $(counter).prop('hidden', false);
                input.countSms(counter);
            } else {
                $(counter).prop('hidden', true);
            }
        }

       

        messageInput.keyup(function () {
            countMessage($(this));
        });

        messageInput.bind('paste', function () {
            setTimeout(function () {
                countMessage(messageInput);
            });
        });

        

        
    });




