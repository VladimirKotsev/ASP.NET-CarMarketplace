let makeSelect = document.querySelector('#MakeSelect');

makeSelect.addEventListener('change', (e) => getMake(e));

function getMake(e) {

    console.log(e.target.value);

    let modelSelect = document.querySelector("#ModelSelect");
    modelSelect.disabled = false;

    let make = makeSelect.options[makeSelect.selectedIndex].text;

    let arr = JSON.stringify(localStorage.getItem("Models"));
    console.log(arr);
    
    //for (let i = 0; i < Model.Models.length; i++) {
    //    console
    //}
}

let htmlTemplate = `
@foreach (var item in Model.Models.Where(m => m.ManufacturerName == ViewData["Make"]))
{
    <option value="@item.Id">@item.ModelName</option>
}`;

//function SetViewData() {
//    let select = document.querySelector('#MakeSelect')
//    let make = select.options[select.selectedIndex].text;

//    document.querySelector("#ModelSelect").disabled = false;
//    let data = {
//        'key': "Make",
//        'value': make
//    }

//    $.ajax({
//        type: "POST",
//        url: '/Catalog/SetViewData',
//        data: data,
//        success: function (response) {
//            let modelSelect = document.querySelector("#ModelSelect");

//            foreach
//        },
//        error: function (request, status, error) {
//            console.log("error")
//        }
//    });
//}


