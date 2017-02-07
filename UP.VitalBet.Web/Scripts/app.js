$(function () {

    'use strict';




    var ViewModel = function () {
        var self = this;
        self.matches = ko.observableArray([]);

        self.updateIntervalInMSs = 10000;
        // Reference the auto-generated proxy for the hub.
        self.feed = $.connection.broadcasterHub;
        // Create a function that the hub can call back to display messages.
        self.feed.client.matchFeed = function (matches) {
            console.log('Matches received....');
            var result = [];
            $.each(matches, function (index, value) {
                var localizedDate = moment.utc(value.StartDate).toDate();
                localizedDate = moment(localizedDate).format('YYYY-MM-DD HH:mm:ss');
                result.push({name: value.Name, startDate: localizedDate})
            })
            self.matches(result);

        };

        // Start the connection.
        $.connection.hub.start().done(function () {
            self.pullMatches()
            setInterval(self.pullMatches, self.updateIntervalInMSs);
        });

        self.pullMatches = function () {
            self.feed.server.pullMatches();
            console.log('Pull matches initiated...');
        }
    };

    ko.applyBindings(new ViewModel());
});