let genreId;
const deleteObj = (id) => {
    genreId = id;
    $('#deleteGenreModal').modal('show');
};

const deleteGenre = async () => {
  $('#delete-form').submit(function (e) { 
    e.preventDefault();
    
  });

  fetch(`http://localhost:5078/Genres/Index/Delete/${genreId}`,
  {
    method : "POST",
    body: JSON.stringify(genreId),
    mode:"cors",
    headers: {
      RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value,
      'Content-Type': 'application/json',
      Accept: 'application/json',
  }
  }).then( (succ) =>
     window.location.replace("http://localhost:5078/Genres")
  ).catch( (err) => 
    console.log(err)
  )
} 

// const deleteObj = (id) => {
//   $('#deleteGenreModal').modal("show");
//   $('#delete-form').attr('formaction', `/Genres/Delete/${id}`);
// }