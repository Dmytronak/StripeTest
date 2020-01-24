function subscribe(event) {
    event.preventDefault();
    let loginData = $('#loginForm').serialize();
    $.ajax({
        type: 'POST',
        url: '/api/',
        data: loginData,
        success: (function (response) {
          
        }),
        error: (function (error) {
            $('#loginErrorMessage').text('Error. Not subscribe')
            $('#loginErrorMessage').removeClass('d-none');
            console.log(error.statusText);
        })
    });
}