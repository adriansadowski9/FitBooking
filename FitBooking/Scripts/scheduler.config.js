scheduler.customConfiguration = function () {
    scheduler.attachEvent("onEventSave", function (id, ev, is_new) {
        if (!ev.text) {
            dhtmlx.alert("Opis nie możebyć pusty");
            return false;
        }

        return true;
    });
};

//function block_readonly() {
//    var event = scheduler.getEvent(70);
//    //if (rvid == undefined) return true;
//    return event.readonly;
//};

//scheduler.attachEvent("onBeforeDrag", block_readonly);
//scheduler.attachEvent("onDblClick", block_readonly);

