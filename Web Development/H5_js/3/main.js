
/*
Toteuta websivulle toiminnallisuus, jossa muutat annetut fahrenheit asteet celcius asteiksi.
Kaava on T(°C) = (T(°F) - 32) × 5/9
Pyöristä tulos kahteen desimaaliin.
*/

// Get the button
const convertButton = document.getElementById("convertButton");

// Get the input
const fahrenheitInput = document.getElementById("fahrenheitInput");

// Get the output
const celsiusOutput = document.querySelector(".celsius");

// Add event listener
convertButton.addEventListener("click", convertButtonHandler);

// Event handler
function convertButtonHandler() {
    const fahrenheit = fahrenheitInput.value;
    const celsius = (fahrenheit - 32) * 5/9;
    celsiusOutput.textContent = celsius.toFixed(2) + " °C";
}