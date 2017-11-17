(function () {

    angular
        .module(APP.NAME).controller("foundController", FoundController);

    FoundController.$inject = ['foundService', "toastr"];

    function FoundController(foundService, toastr) {
        var vm = this;

        vm.found = null;

        vm.onSubmitBtnClicked = _onSubmitBtnClicked;


        function _onSubmitBtnClicked() {


                foundService.addItem(vm.found, _onAddItemSuccess, _onAddItemError);

           
        }

        function _onAddItemSuccess(response) {
            toastr.success("You have successfully submitted");
        };
        function _onAddItemError(response) {
            toastr.error("Oops!");
        };
    }

})();

