$(document).ready(function() {
  var date = new Date();
  $('#date').val(date.toISOString());
});

$(document).on('click', '#save-btn', function(evt) {
  $('#name').removeClass('invalid');
  $('#date').removeClass('invalid');
  $('#tweet').removeClass('invalid');
  $('.error').html('');

  let inputsValid = true;

  // Check for valid twitter handle
  if (!$('#name').val()) {
    $('#name-error').html("Name cannot be empty");
    $('#name').addClass('invalid');
    inputsValid = false;
  }

  // Check for valid date time format
  if (!$('#date').val()) {
    $('#date-error').html("Date cannot be empty");
    $('#date').addClass('invalid');
    inputsValid = false;
  }

  // Check tweet is nonempty
  if (!$('#tweet').val()) {
    $('#tweet-error').html("Tweet cannot be empty");
    $('#date').addClass('invalid');
    inputsValid = false;
  }

  if (!inputsValid) {
    return;
  }
});
