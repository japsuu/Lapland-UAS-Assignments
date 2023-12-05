
/*
Tapahtumankäsittelijän luominen: Luo seuraavan lainen websivusto ja tapahtuman -
käsittelijät painonapeille. Kun käyttäjä painaa
• Change name! –nappia, näytä nimenä ”Donald Duck”.
• Change color! –nappia, vaihda nimen taustaväriksi punainen (eli esim. Mickey Mouse
tekstillä olisi punainen taustaväri)
• Back to original name –nappia, näytä alkuperäinen nimi eli “Mickey Mouse”
• Back to original color –nappia, vaihda nimen taustaväri takaisin
• Back to original –nappia, näytä nimenä ”Mickey Mouse” valkoisella taustalla
*/

// Get the buttons
const changeName = document.getElementById("changeName");
const changeColor = document.getElementById("changeColor");
const backToOriginalName = document.getElementById("backToOriginalName");
const backToOriginalColor = document.getElementById("backToOriginalColor");
const backToOriginal = document.getElementById("backToOriginal");

// Get the text
const dynamicText = document.querySelector(".dynamicText");

// Add event listeners
changeName.addEventListener("click", changeNameHandler);
changeColor.addEventListener("click", changeColorHandler);
backToOriginalName.addEventListener("click", backToOriginalNameHandler);
backToOriginalColor.addEventListener("click", backToOriginalColorHandler);
backToOriginal.addEventListener("click", backToOriginalHandler);

// Event handlers
function changeNameHandler() {
  dynamicText.textContent = "Donald Duck";
}

function changeColorHandler() {
  dynamicText.style.backgroundColor = "red";
}

function backToOriginalNameHandler() {
    dynamicText.textContent = "Mickey Mouse";
}

function backToOriginalColorHandler() {
    dynamicText.style.backgroundColor = "white";
}

function backToOriginalHandler() {
    dynamicText.textContent = "Mickey Mouse";
    dynamicText.style.backgroundColor = "white";
}