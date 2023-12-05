/*
Käytä hyödyksesi cars_data.js. nimistä tiedostoa, joka sisältää ohjelmassa vaaditun datan.
    HTML tiedostossa sisällytetään data tiedosto, jonka jälkeen voidaan vapaasti käyttää datatiedostossa määriteltyä
cars nimistä muuttujaa (käytännössä isohko array). Käsittele kyseistä arrayta iteraatiometodeilla ja näytä
tulokset html sivulla. Voit katsoa apua myös https://www.w3schools.com/js/js_array_iteration.asp

    cars_data sisältämä array sisältää autoja muodossa:
{
    "manufacturer":"Porsche",
    "model": "911",
    "price": 135000,
    "quality": [
    {
        "name":"overall",
        "rating":3
    },
    {
        "name":"mechanical",
        "rating":4
    },
    {
        "name":"powertrain",
        "rating":2
    },
    {
        "name":"body",
        "rating":4
    },{
        "name":"interior",
        "rating":3
    },
    {
        "name":"accessories",
        "rating":2
    }
],
    "wiki":"http://en.wikipedia.org/wiki/Porsche_997"
}

a. Näytä jokaisesta autosta seuraavat tiedot HTML tablessa:
    • manufacturer, model, price, linkki wikiin

b. Lisää HTML-taulukkoon sarake ”Quality”. Tässä sarakkeessa näytä vain overall arvosana.
*/

// Show the cars in the carsTable.
function showCars() {
    // Get the table.
    let carsTable = document.getElementById("carsTable");

    // Loop through the cars.
    for (let i = 0; i < cars.length; i++) {
        // Create a new row.
        let row = carsTable.insertRow(i + 1);

        // Create a new cell for each car property.
        let manufacturerCell = row.insertCell(0);
        let modelCell = row.insertCell(1);
        let priceCell = row.insertCell(2);
        let qualityCell = row.insertCell(3);
        let averageQualityCell = row.insertCell(4);
        let wikiCell = row.insertCell(5);

        // Calculate the average quality.
        let averageQuality = 0;
        for (let j = 0; j < cars[i].quality.length; j++) {
            averageQuality += cars[i].quality[j].rating;
        }
        averageQuality /= cars[i].quality.length;

        // Add the car properties to the cells.
        manufacturerCell.innerHTML = cars[i].manufacturer;
        modelCell.innerHTML = cars[i].model;
        priceCell.innerHTML = cars[i].price;
        qualityCell.innerHTML = cars[i].quality[0].rating;
        averageQualityCell.innerHTML = averageQuality.toFixed(2).toString();
        wikiCell.innerHTML = "<a href='" + cars[i].wiki + "'>" + cars[i].wiki + "</a>";
    }
}

// Show the cars when the page is loaded.
window.onload = showCars;