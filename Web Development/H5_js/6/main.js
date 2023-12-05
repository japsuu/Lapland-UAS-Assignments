
/*
Tee ohjelma, jonka avulla voit laskea saamasi kilometrikorvaus tietyllä matkalla. Oletetaan,
että kilometrikorvaus olisi 53c / km yksin matkustettaessa ja kasvaa kuljetettavien
henkilömäärän 4 senttiä per kuljetettava henkilö.
*/

// Get the button
const calculateButton = document.getElementById("calculateButton");

// Get the inputs
const distanceInput = document.getElementById("distanceInput");
const passengersInput = document.getElementById("passengersInput");

// Get the output
const allowanceOutput = document.querySelector(".allowance");

// Add event listener
calculateButton.addEventListener("click", calculateButtonHandler);

// Event handler
function calculateButtonHandler() {
    const distance = distanceInput.value;
    const passengers = passengersInput.value;
    const allowance = (53 + ((passengers - 1) * 4)) * distance;
    if (allowance < 100){
        allowanceOutput.textContent = "Allowance: " + allowance + " cents";
    }else{
        allowanceOutput.textContent = "Allowance: " + allowance/100 + " euros";
    }
}