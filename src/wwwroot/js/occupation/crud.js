let occupationId;
let occupationBaseURI = "http://localhost:5078/Occupations/Index";

const deleteObj = (id) => {
    occupationId = id;
    $('#deleteOccupationModal').modal('show');
};

const deleteOccupation = async () => {
  $('#delete-form').submit(function (e) { 
    e.preventDefault();
  });

  fetch(`${occupationBaseURI}/Delete/${occupationId}`,
  {
    method : "POST",
    headers: {
      RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value,
      'Content-Type': 'application/json',
      Accept: 'application/json',
  }
  }).then( () => window.location.replace("http://localhost:5078/occupations"));
} 

const InfoObj = async (name) => {
  $('#inf-ocp-name').text(name); 
  $('#detailOccupationModal').modal("show");
}


// TODO : Complete SPA operations with JS
