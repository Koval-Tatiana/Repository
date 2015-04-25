angular
    .module("app", [])
    .controller("Contorller1", ["$scope",
        function ($scope) {

            $scope.name = "Test";

            $scope.items = [];
            $scope.archiveItems = [];
            $scope.newItem = {
                done: false,
                name: "",
                priority: "",
                performer: ""
            };

//Удалить выбранные
            $scope.delete = function () {
                var oldItems = $scope.items;
                $scope.items = [];
                angular.forEach(oldItems, function (item) {
                    if (!item.done) $scope.items.push(item);
                });
            };
//Поместить в архив выбранные
            $scope.archive = function () {
                var oldItems = $scope.items;
                $scope.items = [];
                angular.forEach(oldItems, function (item) {
                    if (!item.done) $scope.items.push(item);
                    else $scope.archiveItems.push(item);
                });
            };
//Удалить текущий
            $scope.del = function (item) {
                var index = $scope.items.indexOf(item);
                $scope.items.splice(index, 1);
            };
//Поместить в архив текущий
            $scope.arch = function (item) {
                $scope.archiveItems.push(item);
                $scope.del(item);
            };
//Добавить
            $scope.add = function () {
                if ($scope.newItem.name != "" || $scope.newItem.priority != "" || $scope.newItem.performer != "") {
                    $scope.items.push({
                        done: false,
                        name: $scope.newItem.name,
                        priority: $scope.newItem.priority,
                        performer: $scope.newItem.performer
                    });

                    $scope.newItem.name = "";
                    $scope.newItem.priority = "";
                    $scope.newItem.performer = "";
                }

            };

        }]);


