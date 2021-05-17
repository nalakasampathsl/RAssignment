var urlPath = window.location.pathname;
$(function () {
    ko.applyBindings(ASListVM);
    ASListVM.getAircraftSightings();
});

//View Model
var ASListVM = {
    AircraftSightings: ko.observableArray([]),
    getAircraftSightings: function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: '/ASighting/FetchAircraftSightings',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.AircraftSightings(data); //Put the response in ObservableArray                
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    },
};

self.editASighting = function (asValues) {
    window.location.href = '/ASighting/Edit/' + asValues.Id;
};
self.detailsASighting = function (asValues) {
    window.location.href = '/ASighting/Details/' + asValues.Id;
};
self.deleteASighting = function (asValues) {
    window.location.href = '/ASighting/Delete/' + asValues.Id;
};

//Model
function AircraftSightings(data) {
    this.Id = ko.observable(data.Id);
    this.Make = ko.observable(data.Make);
    this.Mode = ko.observable(data.Mode);
    this.Registration = ko.observable(data.Registration);
    this.Location = ko.observable(data.Location);
    this.DateAndTime = ko.observable(data.DateAndTime);


}

function dateFormat(d) {
    console.log(d);
    return ((d.getMonth() + 1) + "").padStart(2, "0")
        + "/" + (d.getDate() + "").padStart(2, "0")
        + "/" + d.getFullYear()
        + " " + d.getHours()
        + ":" + d.getMinutes()
        + ":" + d.getSeconds();
}
