function readonlyEvents() {
    scheduler.attachEvent("onEventLoading", function (ev) {
        //  scheduler.serverList("blocked_time");
        if (ev.readonly == true)  {
            scheduler.attachEvent("onLightbox", function () {
               // var section = scheduler.formSection("description");
               // section.control.disabled = true;
               // ev.
            });
            var buttons = ["delete", "edit"];
            for (var i = 0; i < buttons.length; i++) {
                var oldAction = scheduler._click.buttons[buttons[i]];
                scheduler._click.buttons[buttons[i]] = function (id) {                                 //disable 'edit' and 'delete' buttons for old events
                    // if (+scheduler.getEvent(id).start_date < +new Date())
                    return;
                    // else
                   /// oldAction.apply(scheduler, arguments);
                   // return;
                };

            }
            
        }
        // scheduler.config.readonly = true;
        return true;
        
    }
    );
}
 

function readOnly(ev) {
    scheduler.attachEvent("onDblClick", function (id, e) {
        if (e.getEvent(id) == true) {
            return false;
        }
        return true;
    })
}

function init() {
    scheduler.attachEvent("onBeforeLightbox", function (id, mode, native_event) {
        if (+scheduler.getEvent(id).start_date < +new Date())
            scheduler.config.readonly_form = true;//readonly form for old events
        else
            scheduler.config.readonly_form = false;//regular form for others
        return true;
    });

    scheduler.attachEvent("onBeforeDrag", function (id, mode, event) {
        if (+scheduler.getActionData(event).date < +new Date())
            return false;
        return true;
    });

    var buttons = ["delete", "edit"];
    for (var i = 0; i < buttons.length; i++) {
        var oldAction = scheduler._click.buttons[buttons[i]];
        scheduler._click.buttons[buttons[i]] = function (id) {                                 //disable 'edit' and 'delete' buttons for old events
            if (+scheduler.getEvent(id).start_date < +new Date())
                return;
            else
                oldAction.apply(scheduler, arguments);
        };
    }


  
//        return true;
 

}

