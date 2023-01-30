let labelId;
let labelBaseURI = "http://localhost:5078/Labels/Index";

const deleteObj = (id) => {
    labelId = id;
    $('#deleteLabelModal').modal('show');
};

const deleteLabel = async () => {
  $('#delete-form').submit(function (e) { 
    e.preventDefault();
  });

  fetch(`${labelBaseURI}/Delete/${labelId}`,
  {
    method : "POST",
    headers: {
      RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value,
      'Content-Type': 'application/json',
      Accept: 'application/json',
  }
  }).then( () => window.location.replace("http://localhost:5078/labels"));
} 

const InfoObj = async (id) => {
  // $('#')
  const response = await (await fetch(`${labelBaseURI}/Detail/${id}`)).json();
  // $('#dtl-lb-id').text(response.Id);
  const parsed = JSON.parse(response);
  const {Id, Name, Parent, Founded, CountryOfOrigin, Location, Website} = parsed;
  $('#dtl-lb-id').text(Id);
  $('#dtl-lb-name').text(Name);
  $('#dtl-lb-parent').text(Parent);
  $('#dtl-lb-founded').text(Founded);
  $('#dtl-lb-country-of-origin').text(CountryOfOrigin);
  $('#dtl-lb-location').text(Location);
  $('#dtl-lb-website').attr("href",`https://${Website}`);
  $('#detailLabelModal').modal("show");
}


// TODO : Complete SPA operations with JS