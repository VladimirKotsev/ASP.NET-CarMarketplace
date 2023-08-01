let makeSelect = document.querySelector('#MakeSelect');

makeSelect.addEventListener('change', (e) => getMake(e));

function getMake(e) {

    console.log(e.target.value);
    
    document.querySelector("#ModelSelect").disabled = false;
    <%= 
        
    %>
}
