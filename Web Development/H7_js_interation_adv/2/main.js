/*
Näytä students_data.js tiedostossa olevat tiedot HTML-tablessa.
Taulukon tulee sisältää opeiskelijan tiedot, lukuunottamatta kurssisuorituksia.
*/

// Function to show students of a specific study field and gender
function showStudentsByStudyFieldAndGender(studyField) {
    // Clear the table first
    const studentsTable = document.getElementById('studentsTable');
    while (studentsTable.rows.length > 1) {
        studentsTable.deleteRow(1);
    }

    // Get the selected gender
    const selectedGender = document.querySelector('input[name="gender"]:checked').value;

    // Get the selected sort order
    const selectedSortOrder = document.querySelector('input[name="sort"]:checked').value;

    // Filter the students data based on study field and gender
    let filteredStudents = students.filter(function (student) {
        const genderMatches = selectedGender === 'all' || student.gender === selectedGender;
        const studyFieldMatches = studyField === '' || student.study_field.toLowerCase().includes(studyField.toLowerCase());
        return genderMatches && studyFieldMatches;
    });

    // Sort the filtered students based on the selected sort order
    filteredStudents.sort(function (a, b) {
        if (selectedSortOrder === 'alphabetical') {
            return a.firstname.localeCompare(b.firstname);
        } else { // selectedSortOrder === 'age'
            return a.age - b.age;
        }
    });

    // Add the filtered students to the table
    filteredStudents.forEach(function(student, index) {
        const row = studentsTable.insertRow(index + 1);

        // Create a new cell for each student property
        const idCell = row.insertCell(0);
        const firstNameCell = row.insertCell(1);
        const lastNameCell = row.insertCell(2);
        const genderCell = row.insertCell(3);
        const studyFieldCell = row.insertCell(4);
        const addressCell = row.insertCell(5);
        const emailCell = row.insertCell(6);
        const phoneCell = row.insertCell(7);
        const ageCell = row.insertCell(8);
        const creditsCell = row.insertCell(9);

        // Calculate the student's credits
        let credits = 0;
        student.courses_done.forEach(function(course) {
            credits += course.credits;
        });

        // Add the student properties to the cells
        idCell.innerHTML = student.student_id;
        firstNameCell.innerHTML = student.firstname;
        lastNameCell.innerHTML = student.lastname;
        genderCell.innerHTML = student.gender;
        studyFieldCell.innerHTML = student.study_field;
        addressCell.innerHTML = student.address;
        emailCell.innerHTML = student.email;
        phoneCell.innerHTML = student.phone;
        ageCell.innerHTML = student.age;
        creditsCell.innerHTML = credits;
    });
}

// Add event listener to the search input field
document.getElementById('searchField').addEventListener('input', function() {
    showStudentsByStudyFieldAndGender(this.value);
});

// Add event listeners to the radio buttons
document.getElementById('all').addEventListener('change', function() {
    showStudentsByStudyFieldAndGender(document.getElementById('searchField').value);
});
document.getElementById('men').addEventListener('change', function() {
    showStudentsByStudyFieldAndGender(document.getElementById('searchField').value);
});
document.getElementById('women').addEventListener('change', function() {
    showStudentsByStudyFieldAndGender(document.getElementById('searchField').value);
});

// Add event listeners to the sort order radio buttons
document.getElementById('alphabetical').addEventListener('change', function() {
    showStudentsByStudyFieldAndGender(document.getElementById('searchField').value);
});
document.getElementById('age').addEventListener('change', function() {
    showStudentsByStudyFieldAndGender(document.getElementById('searchField').value);
});

// Show all students when the page is loaded.
window.onload = function() {
    showStudentsByStudyFieldAndGender('');
};