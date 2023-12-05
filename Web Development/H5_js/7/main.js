
/*
Tee ohjelma, jonka avulla voit laskea saamasi kilometrikorvaus tietyllä matkalla. Oletetaan,
että kilometrikorvaus olisi 53c / km yksin matkustettaessa ja kasvaa kuljetettavien
henkilömäärän 4 senttiä per kuljetettava henkilö.

Tee kehittyneempi versio kilometrikorvaussovelluksesta siten, että otat huomioon
• Montako matkustajaa on ollut kyydissä
• millä kulkuneuvolla olet matkustanut seuraavan taulukon mukaisesti:
Kulkuneuvo Korvauksen enimmäismäärä
auto - 53 snt/km
moottorivene, enintään 50 hv - 93 snt/km
moottorivene, yli 50 hv - 135 snt/km
moottorikelkka - 129 snt/km
mönkijä - 121 snt/km
moottoripyörä - 41 snt/km
mopo - 22 snt/km
muu kulkuneuvo - 13 snt/km
*/

// Get the button
const calculateButton = document.getElementById("calculateButton");

// Get the inputs
const distanceInput = document.getElementById("distanceInput");
const passengersInput = document.getElementById("passengersInput");
const vehicleInput = document.getElementById("vehicleInput");

// Get the output
const allowanceOutput = document.querySelector(".allowance");

// Add event listener
calculateButton.addEventListener("click", calculateButtonHandler);

// Event handler
function calculateButtonHandler() {
    const distance = distanceInput.value;
    const passengers = passengersInput.value;
    const vehicle = vehicleInput.value;
    let allowance;
    switch (vehicle) {
        case "auto":
            allowance = (53 + ((passengers - 1) * 4)) * distance;
            break;
        case "moottorivene, enintään 50 hv":
            allowance = (93 + ((passengers - 1) * 4)) * distance;
            break;
        case "moottorivene, yli 50 hv":
            allowance = (135 + ((passengers - 1) * 4)) * distance;
            break;
        case "moottorikelkka":
            allowance = (129 + ((passengers - 1) * 4)) * distance;
            break;
        case "mönkijä":
            allowance = (121 + ((passengers - 1) * 4)) * distance;
            break;
        case "moottoripyörä":
            allowance = (41 + ((passengers - 1) * 4)) * distance;
            break;
        case "mopo":
            allowance = (22 + ((passengers - 1) * 4)) * distance;
            break;
        case "muu kulkuneuvo":
            allowance = (13 + ((passengers - 1) * 4)) * distance;
            break;
        default:
            allowance = (53 + ((passengers - 1) * 4)) * distance;
            break;
    }
    if (allowance < 100){
        allowanceOutput.textContent = "Allowance: " + allowance + " cents";
    }else{
        allowanceOutput.textContent = "Allowance: " + allowance/100 + " euros";
    }
}