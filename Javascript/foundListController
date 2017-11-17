(function () {

    angular
        .module(APP.NAME).controller("foundListController", FoundListController);

    FoundListController.$inject = ['foundService', "toastr"];

    function FoundListController(foundService, toastr) {
        var vm = this;

        vm.found = null;

        vm.viewBtnClicked = _viewBtnClicked;

        vm.$onInit = _onInit;

        function _onInit() {


            foundService.getItems(_itemSuccess, _itemError);

        }

        function _itemSuccess(response) {

            vm.items = response.data.items;
           

        };

        function _itemError(response) {

        };


        function _viewBtnClicked() {

            $("#myModal").modal('show');
          
        }

   
    };
})();

