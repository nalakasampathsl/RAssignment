var urlPath = window.location.pathname;
$(function () {
    ko.applyBindings(CreateVM);
});

var CreateVM = {
    AircraftSightings: ko.observableArray([]),
    Id: ko.observable(),
    Make: ko.observable(),
    Model: ko.observable(),
    Registration: ko.observable(),
    Location: ko.observable(),
    DateAndTime: ko.observable(),
    SaveASighting: function () {
        $.ajax({
            url: '/ASighting/Create',
            type: 'post',
            dataType: 'json',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
            },
            error: function (err) {
                if (err.responseText == "Creation Failed")
                { window.location.href = '/ASighting/Index/'; }
                else {
                    alert("Status:"+err.responseText);
                    window.location.href = '/ASighting/Index/';;
                }
            },
            complete: function () {
                window.location.href = '/ASighting/Index/';
            }
        });
    }
};
