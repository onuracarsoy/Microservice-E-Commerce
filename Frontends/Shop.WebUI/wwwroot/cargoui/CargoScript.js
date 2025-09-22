
// JavaScript to calculate the progress and adjust the progress bar
const steps = document.querySelectorAll('.step');
let completedSteps = 0;

steps.forEach((step, index) => {
    if (step.classList.contains('completed')) {
        completedSteps++;
    }
});

// Calculate the percentage of completion
const progress = (completedSteps / steps.length) * 100;

// Set the progress bar width dynamically
const progressBar = document.querySelector('.progress-bar-inner');
progressBar.style.width = `${progress}%`;

// Change the color of the progress bar based on completion
if (progress < 100) {
    progressBar.style.backgroundColor = '#FFD22F'; // Blue when active
} else {
    progressBar.style.backgroundColor = '#28a745'; // Green when complete
}
