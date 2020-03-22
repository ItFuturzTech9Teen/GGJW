$(document).ready(function () {

    // Creating A Pattern To Enter Only Decimal Number
    $(document).on('keydown', 'input[pattern]', function (e) {
        var input = $(this);
        var oldVal = input.val();
        var regex = new RegExp(input.attr('pattern'), 'g');

        setTimeout(function () {
            var newVal = input.val();
            if (!regex.test(newVal)) {
                input.val(oldVal);
            }
        }, 0);
    });

    //Create A DropDown Effect On File Upload Button
    $('.dropify').dropify();

    //Create A Simple DataTable Facility With Pagination
    $('#myTable').DataTable(); 
    $('#config-table').DataTable({});
    $('#process_table').DataTable({});
    $('#cancel_table').DataTable({});
    $('#delivery_table').DataTable({});
    $('#shipped_table').DataTable({});
});

