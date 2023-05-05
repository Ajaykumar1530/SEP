// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<script>
    // Select all radio buttons with class "option"
    const options = document.querySelectorAll('.option');

    // Listen for changes to the radio buttons
    options.forEach(option => {
        option.addEventListener('change', () => {
            // Initialize a variable to keep track of the number of correct answers
            let numCorrect = 0;

            // Loop through all the questions
            @foreach(var question in Model)
            {
                // Get the selected answer for this question
                const selectedAnswer = document.querySelector('input[name="question@(question.Id)"]:checked').value;

    // Check if the selected answer matches the correct answer
    if (selectedAnswer === question.CorrectOption.ToString()) {
        numCorrect++;
                }
            }

    // Update the counter display
    const counterDisplay = document.querySelector('#counter-display');
    counterDisplay.textContent = `You have answered ${numCorrect} out of @Model.Count() questions correctly.`;
        });
    });
</script>
