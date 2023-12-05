
/*
Luo websivu, joka laskee kahden päivämäärän erotuksen. Voit esimerkiksi muuttaa
päivämäärän ensin millisekunneiksi ja tehdä vähennyslaskun ja sen jälkeen laskea montako
kokonaista päivää kyseinen erotus on.
*/

// Get the button
const calculateButton = document.getElementById("calculateButton");

// Get the inputs
const date1Input = document.getElementById("date1Input");
const date2Input = document.getElementById("date2Input");

// Get the output
const differenceOutput = document.querySelector(".difference");

// Add event listener
calculateButton.addEventListener("click", calculateButtonHandler);

// Event handler
function calculateButtonHandler() {
    const date1 = new Date(date1Input.value);
    const date2 = new Date(date2Input.value);
    const difference = Math.abs(date1 - date2);
    const days = Math.floor(difference / (1000 * 60 * 60 * 24));
    differenceOutput.textContent = days + " days";
}