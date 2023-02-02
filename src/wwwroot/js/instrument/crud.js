let instrumentBaseURI = "http://localhost:5078/Instruments/Index";
let instrumentId;

const deleteObj = (id) => {
    instrumentId = id;
    $('#deleteInstrumentModal').modal('show');
};

const deleteInstrument = async () => {
  $('#delete-form').submit(function (e) { 
    e.preventDefault();
  });

  fetch(`${instrumentBaseURI}/Delete/${instrumentId}`,
  {
    method : "POST",
    headers: {
      RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value,
      'Content-Type': 'application/json',
      Accept: 'application/json',
  }
  }).then( () => window.location.replace("http://localhost:5078/instruments"));
} 

const InfoObj = (name) => {
	$('#inf-ins-name').text(name);
	$('#detailInstrumentModal').modal("show");
}
