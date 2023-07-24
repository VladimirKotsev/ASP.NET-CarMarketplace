let makeSelect = document.querySelector('#MakeSelect');

makeSelect.addEventListener('change', (e) => getMake(e));

function getMake(event) {

    event.PrevendDefault();

    console.log(event.target.value);
    
    //document.querySelector("#ModelSelect").disabled = false;
    return event.target.value;
}
