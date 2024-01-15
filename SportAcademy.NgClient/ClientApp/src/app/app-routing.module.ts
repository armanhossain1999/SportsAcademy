import { NgModule } from '@angular/core';
import { RouterModule, Routes, ExtraOptions } from '@angular/router';
import { NavbarComponent } from './components/common/navbar/navbar.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { EventListComponent } from './components/admin/event/event-list/event-list.component';
import { EventAddComponent } from './components/admin/event/event-add/event-add.component';
import { EventEditComponent } from './components/admin/event/event-edit/event-edit.component';
import { ManagerListComponent } from './components/admin/manager/manager-list/manager-list.component';
import { EventDeleteComponent } from './components/admin/event/event-delete/event-delete.component';
import { ManagerAddComponent } from './components/admin/manager/manager-add/manager-add.component';
import { ManagerEditComponent } from './components/admin/manager/manager-edit/manager-edit.component';
import { authGuardFnGuard } from './guards/auth-fn.guard';
import { ManagerEventComponent } from './components/admin/manager/manager-event/manager-event.component';
import { ManagerEventsAddComponent } from './components/admin/manager/manager-events-add/manager-events-add.component';
import { SelectionPanelAddComponent } from './components/admin/selectionPanel/selection-panel-add/selection-panel-add.component';
import { SelectionPanelListComponent } from './components/admin/selectionPanel/selection-panel-list/selection-panel-list.component';
import { SelectionPanelEditComponent } from './components/admin/selectionPanel/selection-panel-edit/selection-panel-edit.component';
import { SelectionPanelDeleteComponent } from './components/admin/selectionPanel/selection-panel-delete/selection-panel-delete.component';
import { TeamListComponent } from './components/admin/team/team-list/team-list.component';
import { TeamAddComponent } from './components/admin/team/team-add/team-add.component';
import { TeamEditComponent } from './components/admin/team/team-edit/team-edit.component';
import { PlayerListComponent } from './components/admin/player/player-list/player-list.component';
import { PlayerAddComponent } from './components/admin/player/player-add/player-add.component';
import { PlayerEditComponent } from './components/admin/player/player-edit/player-edit.component';
import { SettingsListComponent } from './components/admin/settings/settings-list/settings-list.component';
import { HomeComponent } from './components/webpage/home/home.component';
import { MatchesComponent } from './components/webpage/matches/matches.component';
import { TeamComponent } from './components/webpage/team/team.component';
import { PlayerComponent } from './components/webpage/player/player.component';
import { BlogComponent } from './components/webpage/blog/blog.component';
import { ContactComponent } from './components/webpage/contact/contact.component';
import { StaffDashboardComponent } from './components/staff/staff-dashboard/staff-dashboard.component';
import { StaffNavbarComponent } from './components/staff/staff-navbar/staff-navbar.component';
import { StaffEventListComponent } from './components/staff/event/staff-event-list/staff-event-list.component';
import { StaffSelectionPanelListComponent } from './components/staff/selectionPanel/staff-selection-panel-list/staff-selection-panel-list.component';
import { StaffTeamListComponent } from './components/staff/team/staff-team-list/staff-team-list.component';
import { StaffPlayerListComponent } from './components/staff/player/staff-player-list/staff-player-list.component';
import { PlayerNavbarComponent } from './components/player/player-navbar/player-navbar.component';
import { PlayerDashboardComponent } from './components/player/player-dashboard/player-dashboard.component';
import { PlayerPlayerListComponent } from './components/player/player/player-player-list/player-player-list.component';
import { PlayerTeamListComponent } from './components/player/team/player-team-list/player-team-list.component';
import { EventViewListComponent } from './components/webpage/event/event-view-list/event-view-list.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { ProfileComponent } from './components/admin/profile/profile.component';

const routes: Routes = [
  {path: 'navbar', component: NavbarComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'admin', component: DashboardComponent},
  {path:'', component: NavbarComponent, children : 
  [
    {path: '', component: DashboardComponent},
    {path: 'admin-dashboard', component: DashboardComponent},
    {path: 'manager-list', component: ManagerListComponent, canActivate: [authGuardFnGuard(['Admin', 'Staff'])]},
    {path: 'manager-add', component: ManagerAddComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'manager-edit/:id', component: ManagerEditComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'event-list', component: EventListComponent, canActivate: [authGuardFnGuard(['Admin', 'Staff'])]},
    {path: 'event-add', component: EventAddComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'event-edit/:id', component: EventEditComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'event-delete', component: EventDeleteComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'manager-events-add', component: ManagerEventsAddComponent},
    {path: 'selectionPanel-list', component: SelectionPanelListComponent, canActivate: [authGuardFnGuard(['Admin', 'Staff'])]},
    {path: 'selectionPanel-add', component: SelectionPanelAddComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'selectionPanel-edit/:id', component: SelectionPanelEditComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'team-list', component: TeamListComponent, canActivate: [authGuardFnGuard(['Admin','Staff'])]},
    {path: 'team-add', component: TeamAddComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'team-edit/:id', component: TeamEditComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'player-list', component: PlayerListComponent, canActivate: [authGuardFnGuard(['Admin','Staff'])]},
    {path: 'player-add', component: PlayerAddComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'player-edit/:id', component: PlayerEditComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'settings-list', component: SettingsListComponent, canActivate: [authGuardFnGuard(['Admin'])]},
    {path: 'profile', component: ProfileComponent},

  ]},

  {path: 'home', component: HomeComponent},
  {path: 'matches', component: MatchesComponent},
  {path: 'events', component: EventViewListComponent},
  {path: 'players', component: PlayerComponent},
  {path: 'blog', component: BlogComponent},
  {path: 'contact', component: ContactComponent},

  {path: '', component: StaffNavbarComponent, children : 
  [
    {path: 'staff-navbar', component: StaffDashboardComponent},
    {path: 'staff-dashboard', component: StaffDashboardComponent},
    {path: 'staff-event-list', component: StaffEventListComponent, canActivate: [authGuardFnGuard(['Staff'])]},
    {path: 'staff-selectionPanel-list', component: StaffSelectionPanelListComponent, canActivate: [authGuardFnGuard(['Staff'])]},
    {path: 'staff-team-list', component: StaffTeamListComponent, canActivate: [authGuardFnGuard(['Staff'])]},
    {path: 'staff-player-list', component: StaffPlayerListComponent, canActivate: [authGuardFnGuard(['Staff'])]},

  ]},

  {path: '', component: PlayerNavbarComponent, children : 
  [
    {path: 'player-navbar', component: PlayerDashboardComponent},
    {path: 'player-dashboard', component: PlayerDashboardComponent},
    {path: 'player-player-list', component: PlayerPlayerListComponent, canActivate: [authGuardFnGuard(['Players'])]},
    {path: 'player-team-list', component: PlayerTeamListComponent, canActivate: [authGuardFnGuard(['Players'])]},

  ]}



];

const routerOptions: ExtraOptions = {
  onSameUrlNavigation: 'reload',
};

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
