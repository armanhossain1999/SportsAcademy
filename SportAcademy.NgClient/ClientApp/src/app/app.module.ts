import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/common/navbar/navbar.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { ForgotPasswordComponent } from './components/authentication/forgot-password/forgot-password.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { SidebarComponent } from './components/common/sidebar/sidebar.component';
import { MatImportModule } from './module/mat-import/mat-import.module';
import { EventListComponent } from './components/admin/event/event-list/event-list.component';
import { EventAddComponent } from './components/admin/event/event-add/event-add.component';
import { EventEditComponent } from './components/admin/event/event-edit/event-edit.component';
import { EventDeleteComponent } from './components/admin/event/event-delete/event-delete.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { EventService } from './services/data/event.service';
import { ManagerService } from './services/data/manager.service';
import { SelectionPanelService } from './services/data/selectionPanel.service';
import { NotifyService } from './services/common/notify.service';
import { ManagerAddComponent } from './components/admin/manager/manager-add/manager-add.component';
import { ManagerEditComponent } from './components/admin/manager/manager-edit/manager-edit.component';
import { ManagerDeleteComponent } from './components/admin/manager/manager-delete/manager-delete.component';
import { TeamListComponent } from './components/admin/team/team-list/team-list.component';
import { TeamAddComponent } from './components/admin/team/team-add/team-add.component';
import { TeamEditComponent } from './components/admin/team/team-edit/team-edit.component';
import { TeamDeleteComponent } from './components/admin/team/team-delete/team-delete.component';
import { ManagerListComponent } from './components/admin/manager/manager-list/manager-list.component';
import { ManagerEventComponent } from './components/admin/manager/manager-event/manager-event.component';
import { LoginService } from './services/authentication/login.service';
import { AuthService } from './services/authentication/auth.service';
import { ConfirmDeleteComponent } from './dialogs/confirm-delete/confirm-delete.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ManagerDialogComponent } from './dialogs/manager-dialog/manager-dialog.component';
import { ManagerEventsAddComponent } from './components/admin/manager/manager-events-add/manager-events-add.component';
import { SelectionPanelListComponent } from './components/admin/selectionPanel/selection-panel-list/selection-panel-list.component';
import { SelectionPanelAddComponent } from './components/admin/selectionPanel/selection-panel-add/selection-panel-add.component';
import { SelectionPanelEditComponent } from './components/admin/selectionPanel/selection-panel-edit/selection-panel-edit.component';
import { SelectionPanelDeleteComponent } from './components/admin/selectionPanel/selection-panel-delete/selection-panel-delete.component';
import { CoachDialogComponent } from './dialogs/coach-dialog/coach-dialog.component';
import { MedicalAdvisorDialogComponent } from './dialogs/medical-advisor-dialog/medical-advisor-dialog.component';
import { CoachService } from './services/data/coach.service';
import { MedicalAdvisorService } from './services/data/medicalAdvisor.service';
import { PlayerListComponent } from './components/admin/player/player-list/player-list.component';
import { PlayerAddComponent } from './components/admin/player/player-add/player-add.component';
import { PlayerEditComponent } from './components/admin/player/player-edit/player-edit.component';
import { PlayerService } from './services/data/player.service';
import { PlayerPlayerStatisticsComponent } from './components/admin/player/player-player-statistics/player-player-statistics.component';
import { PlayerStatisticsService } from './services/data/playerStatistics.service';
import { SportsService } from './services/data/sports.service';
import { TeamPlayerComponent } from './components/admin/team/team-player/team-player.component';
import { CategoryService } from './services/data/category.service';
import { PlayerRolePlayerService } from './services/data/playerPlayerRole.service';
import { SelectionPanelEventComponent } from './components/admin/selectionPanel/selection-panel-event/selection-panel-event.component';
import { SettingsListComponent } from './components/admin/settings/settings-list/settings-list.component';
import { CricketFormatsService } from './services/data/cricketFormat.service';
import { TrainingSessionService } from './services/data/trainingSession.service';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { EquipmentService } from './services/data/equipment.service';
import { CoachSpecializatonService } from './services/data/coachSpecialization.service';
import { HomeComponent } from './components/webpage/home/home.component';
import { TeamComponent } from './components/webpage/team/team.component';
import { PlayerComponent } from './components/webpage/player/player.component';
import { BlogComponent } from './components/webpage/blog/blog.component';
import { ContactComponent } from './components/webpage/contact/contact.component';
import { MatchesComponent } from './components/webpage/matches/matches.component';
import { FooterComponent } from './components/webpage/common/footer/footer.component';
import { WebHeaderComponent } from './components/webpage/common/web-header/web-header.component';
import { StaffDashboardComponent } from './components/staff/staff-dashboard/staff-dashboard.component';
import { StaffNavbarComponent } from './components/staff/staff-navbar/staff-navbar.component';
import { StaffSidebarComponent } from './components/staff/staff-sidebar/staff-sidebar.component';
import { StaffEventListComponent } from './components/staff/event/staff-event-list/staff-event-list.component';
import { StaffSelectionPanelListComponent } from './components/staff/selectionPanel/staff-selection-panel-list/staff-selection-panel-list.component';
import { StaffTeamListComponent } from './components/staff/team/staff-team-list/staff-team-list.component';
import { StaffPlayerListComponent } from './components/staff/player/staff-player-list/staff-player-list.component';
import { PlayerNavbarComponent } from './components/player/player-navbar/player-navbar.component';
import { PlayerSidebarComponent } from './components/player/player-sidebar/player-sidebar.component';
import { PlayerDashboardComponent } from './components/player/player-dashboard/player-dashboard.component';
import { PlayerTeamListComponent } from './components/player/team/player-team-list/player-team-list.component';
import { PlayerPlayerListComponent } from './components/player/player/player-player-list/player-player-list.component';
import { CourseService } from './services/data/course.service';
import { EventViewListComponent } from './components/webpage/event/event-view-list/event-view-list.component';
import { ProfileComponent } from './components/admin/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    DashboardComponent,
    NavbarComponent,
    SidebarComponent,
    EventListComponent,
    EventAddComponent,
    EventEditComponent,
    EventDeleteComponent,
    ManagerAddComponent,
    ManagerEditComponent,
    ManagerDeleteComponent,
    TeamListComponent,
    TeamAddComponent,
    TeamEditComponent,
    TeamDeleteComponent,
    ManagerListComponent,
    ManagerEventComponent,
    ConfirmDeleteComponent,
    ManagerDialogComponent,
    ManagerEventsAddComponent,
    SelectionPanelListComponent,
    SelectionPanelAddComponent,
    SelectionPanelEditComponent,
    SelectionPanelDeleteComponent,
    CoachDialogComponent,
    MedicalAdvisorDialogComponent,
    PlayerListComponent,
    PlayerAddComponent,
    PlayerEditComponent,
    PlayerPlayerStatisticsComponent,
    TeamPlayerComponent,
    SelectionPanelEventComponent,
    SettingsListComponent,
    HomeComponent,
    TeamComponent,
    PlayerComponent,
    BlogComponent,
    ContactComponent,
    MatchesComponent,
    FooterComponent,
    WebHeaderComponent,
    StaffDashboardComponent,
    StaffNavbarComponent,
    StaffSidebarComponent,
    StaffEventListComponent,
    StaffSelectionPanelListComponent,
    StaffTeamListComponent,
    StaffPlayerListComponent,
    PlayerNavbarComponent,
    PlayerSidebarComponent,
    PlayerDashboardComponent,
    PlayerTeamListComponent,
    PlayerPlayerListComponent,
    EventViewListComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatImportModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CanvasJSAngularChartsModule,
    
    
  ],
  providers: [
    HttpClient, EventService, ManagerService, SelectionPanelService, 
    CoachService, NotifyService, LoginService, AuthService, EventService,
    MedicalAdvisorService, PlayerService, PlayerStatisticsService,SportsService,
    CategoryService, PlayerRolePlayerService, CricketFormatsService, 
    TrainingSessionService, EquipmentService, CoachSpecializatonService, CourseService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
