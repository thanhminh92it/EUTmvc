
    $(document).ready(function () {
        var dropdownList = $("#Subtest_SelectSubtest");
        var list = $("#Category_SelectCategory");
        loadData();
        dropdownList.change(function () {
            loadData();
        });
        function loadData() {
            list.prop('disabled', true);
            list.clearSelect();
            var id = dropdownList.val();
            if (id != '') {
                $.getJSON("/Exam/GetJsonData", { id: id }, function (data) {
                    list.fillSelect(list, data);
                })
                    .always(function () {
                        list.prop('disabled', false);
                    })
                    .error(function () {
                        list.clearSelect();
                        alert('Error');
                    });
            }
        }
    });
$.fn.clearSelect = function () {
    return this.each(function () {
        if (this.tagName == 'SELECT')
            this.options.length = 1;
    });
}
$.fn.fillSelect = function (dropdownList, data) {
    return this.clearSelect().each(function () {
        if (this.tagName == 'SELECT') {
            //dropdownList.append('<option val="1">One</option>');
            $.each(data, function (i, item) {
                dropdownList.append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
        }
    });
}
