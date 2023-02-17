$(document).ready(function () {

    $('#image_input').find('#image').click(function () {
        $("#image_input input[type='file']").trigger('click');
    })

    $("#image_input").find("input[type='file']").change(function () {
        $('#image_input #val').text(this.value.replace(/C:\\fakepath\\/i, ''))
    })
})
