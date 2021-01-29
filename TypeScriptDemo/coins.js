"use strict";
function coins(userInput) {
    var strArray = ["Come on, friend. You can do better.", "Would you like to donate to us?", "Invalid input."];
    var paragraph = document.getElementById("output");
    // var userInput2: number = parseFloat(userInput.value);
    // console.log("Parsed float: " + userInput2);
    var accountUser = new user;
    var userInput2 = accountUser.parseInput(userInput);
    // if userInput is greater than 0, perform logic
    if (userInput2 > 0) {
        // standardize
        userInput2 *= 100;
        console.log("After multiplying by 100: " + userInput2);
        // round the value
        userInput2 = Math.round(userInput2);
        console.log("After Math.round(): " + userInput2);
        // number of dimes
        var d = Math.floor(userInput2 / 10);
        userInput2 %= 10;
        console.log("After dime calculation: " + userInput2);
        // number of nickels
        var n = Math.floor(userInput2 / 5);
        userInput2 %= 5;
        console.log("After nickel calculation: " + userInput2);
        // number of pennies
        var p = userInput2;
        console.log("After penny calculation: " + userInput2);
        // DOM manipulation
        if (paragraph != null)
            paragraph.innerHTML = "Number of dimes: " + d + " + Number of nickles: " + n + " + Number of pennies: " + p;
    }
    else {
        // returns 0,1,2 from strArray
        alert(strArray[Math.floor(Math.random() * Math.floor(3))]);
    }
}
var user = /** @class */ (function () {
    function user() {
        this.dollarAmount = 0;
    }
    user.prototype.parseInput = function (userInput) {
        this.dollarAmount = parseFloat(userInput.value);
        console.log("Parsed float: " + this.dollarAmount);
        return this.dollarAmount;
    };
    return user;
}());
