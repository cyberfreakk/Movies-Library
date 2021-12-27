function LogoutUser(){
    localStorage.removeItem("Token");   
    location.href = "index.html"; 
}
GetAllMovies(); 
function GetMovies() {
    let Name = document.getElementById('movie_name').value;
    let Year = parseInt(document.getElementById('movie_year').value);
    fetch(`http://www.omdbapi.com/?apikey=8266bbff&t=${Name}&y=${Year}`)
        .then(res => res.json())
        .then(item => {
            let duration = parseInt(item.Runtime.split(" ")[0]);   
            let rating = parseFloat(item.imdbRating);         
            body = `
                    <div class="card text-black bg-info mb-3 bg-white" style="max-width: 24rem;">                    
                    <div class="card-body bg-white" id="card_body">
                        <p class="card-text">${item.Title}</p>                        
                        <img class="align-center" src="${item.Poster}" alt="movie_img">                        
                        <p class="card-text">Actors: ${item.Actors}</p>
                        <p class="card-text">Year of Release: ${item.Year}</p>
                        <p class="card-text">Directors: ${item.Director}</p>
                        <p class="card-text">Genre: ${item.Genre}</p>
                        <p class="card-text">Rating: ${item.imdbRating}</p>
                        <p class="card-text">Duration: ${item.Runtime}</p>
                        <button class="btn btn-success" onclick="AddMovie('${item.Title}', ${item.Year}, ${duration}, ${rating}, '${item.Actors}')">Add</button>
                     </div>
                </div>
            `;
            document.getElementById('card').innerHTML = body;
        });    
}

function AddMovie(name,year, runtime, rating, actors) {   
    fetch('https://localhost:44378/api/Movie', {
        method: 'POST',
        body: JSON.stringify({ Name : name, Year: year, Duration: runtime, Rating: rating, Actors: actors }),
        headers: {
            'Content-Type': 'application/json',
            'Authorization' : "Bearer " + localStorage.getItem("Token")
        }
    }).then(res => {
        if(res.ok){
            console.log(res);
            document.getElementById("moviesData").innerHTML="";
            GetAllMovies();
        }
        else{
            alert("You are not logged in!")
        }
    });
}

function DeleteMovie(id){
    fetch(`https://localhost:44378/api/Movie/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization' : "Bearer " + localStorage.getItem("Token")
        }
    }).then(res => {
        if(res.ok){
            console.log(res);
            document.getElementById("moviesData").innerHTML="";
            GetAllMovies();
        }
        else{
            alert("You are not logged in!")
        }
    });
}
function GetAllMovies() {
    fetch('https://localhost:44378/api/Movie')
        .then(res => res.json())
        .then(data => {
            let row = '';
            data.map(item => {
                row += `<tr><td>${item.movieId}</td><td>${item.name}</td><td>${item.year}</td><td>${item.duration}</td><td>${item.rating}</td><td>${item.actors}</td><td><button class="btn btn-danger" onclick=DeleteMovie(${item.movieId})>Delete</button></td></tr>`
            });
            document.getElementById('moviesData').innerHTML = row;
        })
}

