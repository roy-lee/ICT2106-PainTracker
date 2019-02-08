$(document).ready(function () {
    console.log("init calendar loaded");

    $("#calendar").fullCalendar({
        // put your options and callbacks here
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay,list'
        },
        editable: true,
        eventLimit: true, // when too many events in a day, show the popover
        nowIndicator: true,
        eventSources: [{
            //url: 'data/events.json', // use the `url` property
            url: 'https://localhost:44361/Events/get'
            
        }
        ]
    });

    var calendar = $('#calendar').fullCalendar('getCalendar');;
    // Get selected date in day view
    calendar.on('dayClick', function (date, jsEvent, view) {
        console.log(new Date(date) + " is clicked");
    });
    
});