using BookingReservationConsoleApp;
using BookingReservationConsoleApp.Interface;
using BookingReservationConsoleApp.Repository;
using BookingReservationConsoleApp.Service;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddSingleton<IApp, App>()
    .AddSingleton<IHotelSelector, HotelSelectorService>()
    .AddSingleton<IRoomSelector, RoomSelectorService>()
    .AddSingleton<IReservationDisplayer, ReservationDisplayerService>()
    .AddSingleton<IReservationDateGetter, ReservationDateGetterService>()
    .AddSingleton<IReservationMaker, ReservationMakerService>()
    .AddSingleton<IHotelRepository, HotelRepository>()
    .AddSingleton<IReservationRepository, ReservationRepository>()
    .AddSingleton<HotelService>()
    .AddSingleton<ReservationService>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();

app.Run();
