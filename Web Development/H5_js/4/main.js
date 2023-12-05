
/*
Toteuta html sivu, joka kysyy lämpötilaa ja näyttää erilaisen tekstin riippuen annetusta
lämpötilasta. Voit kirjoittaa käyttöliittymän tekstit suomeksi tai englanniksi.
• "Erittäin kylmää", jos lämpötila on alle -40 astetta
• “Melko kylmää, jos lämpötila on (-40)- (-20) astetta.
• "Normaali talvipäivä", jos lämpötila (-19) – (-5) degrees.
• "Leutoa", jos lämpötila välillä -5 – (+5) astetta.
• "Kevättä", jos lämpötila 6-15 degrees.
• "Lämmintä", jos lämpötila 16-25 degrees.
• "Kuumaa", jos lämpötila 26-40 astetta
*/

// Get the button
const checkButton = document.getElementById("checkButton");

// Get the input
const temperatureInput = document.getElementById("temperatureInput");

// Get the output
const weatherOutput = document.getElementById("weatherOutput");

// Add event listener
checkButton.addEventListener("click", checkButtonHandler);

// Event handler
function checkButtonHandler() {
    const temperature = temperatureInput.value;
    if (temperature < -40) {
        weatherOutput.textContent = "Erittäin kylmää";
    } else if (temperature >= -40 && temperature <= -20) {
        weatherOutput.textContent = "Melko kylmää";
    } else if (temperature >= -19 && temperature <= -5) {
        weatherOutput.textContent = "Normaali talvipäivä";
    } else if (temperature >= -5 && temperature <= 5) {
        weatherOutput.textContent = "Leutoa";
    } else if (temperature >= 6 && temperature <= 15) {
        weatherOutput.textContent = "Kevättä";
    } else if (temperature >= 16 && temperature <= 25) {
        weatherOutput.textContent = "Lämmintä";
    } else if (temperature >= 26 && temperature <= 40) {
        weatherOutput.textContent = "Kuumaa";
    }
}