
/*
Use a button to sum the numbers from two input fields and display the result.
*/

// Get the button
const sumButton = document.getElementById("sumButton");

// Get the input fields
const price1 = document.querySelector(".price1");
const price2 = document.querySelector(".price2");

// Get the div where the sum is displayed
const productPriceSum = document.querySelector(".productPriceSum");

// Add event listener
sumButton.addEventListener("click", sumHandler);

// Event handler
function sumHandler() {
    // Get the values from the input fields
    const price1Value = price1.value;
    const price2Value = price2.value;

    // Calculate the sum
    const sum = Number(price1Value) + Number(price2Value);

    // Display the sum
    productPriceSum.textContent = "Tuotteiden kokonaishinta on " + sum + " €";
}