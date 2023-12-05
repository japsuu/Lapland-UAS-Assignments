
/*
Toteuta web sivusto, jossa lasketaan kirjeen tai paketin postikulut seuraavan taulukon mukaisesti:
Tyyppi, Perushinta, Painoluokka
Tyyppi, Perushinta, < 200g, 200g - 500g, > 500g
Kirje, 50 senttiä, ei lisäkuluja, 4 senttiä / 100g, 7 c / 100g
Paketti, 2 euroa, ei lisäkuluja, 8 senttiä / 100g, 14 c / 100g
*/

// Get the button
const calculateButton = document.getElementById("calculateButton");

// Get the inputs
const typeInput = document.getElementById("typeInput");
const weightGramsInput = document.getElementById("weightInput");

// Get the output
const postageOutput = document.querySelector(".postage");

// Add event listener
calculateButton.addEventListener("click", calculateButtonHandler);

// Event handler
function calculateButtonHandler() {
    // Get the values
    const type = typeInput.value;
    const weightGrams = weightGramsInput.value;

    // Calculate the postage
    let postage = 0;

    if (type === "letter") {
        postage = calculateLetterPostage(weightGrams);
    } else if (type === "package") {
        postage = calculatePackagePostage(weightGrams);
    }

    // Display the postage
    postageOutput.textContent = `The postage is ${postage} euros.`;
}

// Helper functions
function calculateLetterPostage(weightGrams) {
    let postage = 0.5;
    if (weightGrams > 200) {
        postage += Math.ceil((weightGrams - 200) / 100) * 0.04;
    }
    if (weightGrams > 500) {
        postage += Math.ceil((weightGrams - 500) / 100) * 0.07;
    }
    return postage;
}


function calculatePackagePostage(weightGrams) {
    let postage = 2;
    if (weightGrams > 200) {
        postage += Math.ceil((weightGrams - 200) / 100) * 0.08;
    }
    if (weightGrams > 500) {
        postage += Math.ceil((weightGrams - 500) / 100) * 0.14;
    }
    return postage;
}