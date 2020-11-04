function generateCalendar(events) {
    $("#calendar").fullCalendar({
        defaultView: 'month',
        contentHeight: 500,
        businessHours: true,
        header: {
            left: 'month, agendaWeek, today',
            center: 'title',
            right: 'prevYear, prev, next, nextYear'
        },
        timeFormat:"h(:mm)a",
        events: events,
        eventClick: function (event) {
            console.log(event);
            $("#eventName").text(event.title);
            $("#eventDesc").text(event.description);
            $("#startTime").text("Start Time: " + moment(event.start).format("DD-MMM-YYYY HH:mm"));
            if (event.start < $.now()) {
                $('#bookLink').text("Event finished");
                $('#bookLink').attr("href", "#");
            } else {
                $('#bookLink').text("Book Now");
                var url = "/BookEvent/Book/" + event.eventId;
                $('#bookLink').attr("href", url);
            }
            
        }
    });
}