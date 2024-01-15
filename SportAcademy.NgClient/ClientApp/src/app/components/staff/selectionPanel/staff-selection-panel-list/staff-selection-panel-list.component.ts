import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Coach } from 'src/app/models/data/coach';
import { MedicalAdvisor } from 'src/app/models/data/medicaladvisor';
import { SelectionPanel } from 'src/app/models/data/selectionPanel';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CoachService } from 'src/app/services/data/coach.service';
import { EventService } from 'src/app/services/data/event.service';
import { MedicalAdvisorService } from 'src/app/services/data/medicalAdvisor.service';
import { SelectionPanelService } from 'src/app/services/data/selectionPanel.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-staff-selection-panel-list',
  templateUrl: './staff-selection-panel-list.component.html',
  styleUrls: ['./staff-selection-panel-list.component.scss']
})
export class StaffSelectionPanelListComponent implements OnInit {

  selectionPanel: SelectionPanel[] = [];
  coaches: Coach[] = [];
  medicalAdvisors: MedicalAdvisor[] = [];
  events: Event[] = [];
  searchTerm: string = '';


  selectonPanelDataSource: MatTableDataSource<SelectionPanel> = new MatTableDataSource(this.selectionPanel);
  coachDataSource: MatTableDataSource<Coach> = new MatTableDataSource(this.coaches);
  medicalAdvisorDataSource: MatTableDataSource<MedicalAdvisor> = new MatTableDataSource(this.medicalAdvisors);
  eventDataSource: MatTableDataSource<Event> = new MatTableDataSource(this.events);

  selectionColumns: string[] = ['selectionPanelName', 'coachName', 'medicalAdvisorName', 'expand', 'actions'];

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  imagePath: string = apiBaseUrl + '/Pictures';
  expandedElement: Event | null = null;

  constructor(
    private selectionPanelService: SelectionPanelService,
    private coachService: CoachService,
    private medicalAdvisorService: MedicalAdvisorService,
    private eventService: EventService,
    private notifyService: NotifyService,
    private dialog: MatDialog
  ) { }

  getCoachName(coachId: number | undefined): string {
    if (coachId !== undefined) {
      const coach = this.coaches.find(c => c.coachId === coachId);
      return coach?.coachName || 'N/A';
    }
    return 'N/A';
  }

  getMedicalAdvisorName(medicalAdvisorId: number | undefined): string {
    if (medicalAdvisorId !== undefined) {
      const medicaladvisor = this.medicalAdvisors.find(c => c.medicalAdvisorId === medicalAdvisorId);
      return medicaladvisor?.medicalAdvisorName || 'N/A';
    }
    return 'N/A';
  }

  ngOnInit() {
    this.selectionPanelService.getSelectionPanelsWithEvents()
      .subscribe({
        next: selectionPanels => {
          this.selectionPanel = selectionPanels;
          console.log(this.selectionPanel);
          this.selectonPanelDataSource.data = this.selectionPanel;
          this.selectonPanelDataSource.sort = this.sort;
          this.selectonPanelDataSource.paginator = this.paginator;

          this.selectonPanelDataSource.filterPredicate = (data, filter) => {
            const searchTermLowerCase = filter.toLowerCase();

            // Use nullish coalescing operator to handle possible undefined values
            return (
              (data.selectionPanelName ?? '').toLowerCase().includes(searchTermLowerCase)
            );
          };
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load SelectionPanel data!");
        }
      });
    this.coachService.getCoaches().subscribe({
      next: r => {
        this.coaches = r;
        this.coachDataSource.data = this.coaches;
        this.coachDataSource.sort = this.sort;
        this.coachDataSource.paginator = this.paginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Coach data!");
      }
    });
    this.medicalAdvisorService.getMedicalAdvisors().subscribe({
      next: r => {
        this.medicalAdvisors = r;
        this.medicalAdvisorDataSource.data = this.medicalAdvisors;
        this.medicalAdvisorDataSource.sort = this.sort;
        this.medicalAdvisorDataSource.paginator = this.paginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Medical Advisors data!");
      }
    });
  }
  applyFilter() {
    this.selectonPanelDataSource.filter = this.searchTerm.trim().toLowerCase();
  }
  
}  