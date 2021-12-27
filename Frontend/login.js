function LoginUser() {
    let UserId = document.getElementById('uid').value;
    let Password = document.getElementById('password').value;
    fetch('https://localhost:44307/api/auth/login', {
        method: 'POST',
        body: JSON.stringify({ UserId, Password}),
        headers: {
            'Content-Type': 'application/json'            
        }
    }).then(res => res.json())
      .then(data =>{
      console.log(data);
      localStorage.setItem("Token",data.token);   
      location.href = "home.html";      
    }).catch(i =>{
        alert("Wrong Credentials Entered!!");
    })
}