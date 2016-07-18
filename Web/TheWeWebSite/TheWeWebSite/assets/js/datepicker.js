   $(function() {
       $( ".dp" ).each(function(){
           $(this).datepicker({
               changeYear: true,
               changeMonth: true,
               dateFormat: "yy-mm-dd"
           });
       })
   });
