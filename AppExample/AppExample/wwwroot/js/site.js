window.onload = function() {
    const demoButton = document.getElementById("demo-button");
    
    let counterValue = 0;
    const counter = document.getElementById("demo-counter-value");

    demoButton.addEventListener('click', function (event) {
        counterValue++;
        counter.innerText = counterValue;
    }, false);
};