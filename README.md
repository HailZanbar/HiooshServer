# Hioosh API Server
The main essence of the project is to be a server for various clients who use the Hioosh app.
The web service implementaion restful API.
The web service run at address 'localhost:5034'.

The project contains three different parts:
1. Rankings page
2. API server.
3. Implementaion of real-time communication by signalR.`

## Rating
If you want to rate the app, you can do it in the rankings page that show when you run the server.
You can add a rating, edit your rating, delete ratings, search for rankings among existing rankings, and you can also view the average numerical rating.

## Web service - API server
The API supports answers in json format.
We implemented all the functions defined in the exercise in the appropriate contollers.

## SignalR
We implemented real-time communication capability, by signalR.
We created the ChatHub and by it and by the requests sent from the clients real-time communication takes place.

