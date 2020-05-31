connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();
connection.start()
    .catch(err => connection.start());