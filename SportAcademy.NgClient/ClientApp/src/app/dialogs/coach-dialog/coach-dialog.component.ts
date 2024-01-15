import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { CoachIdParams } from 'src/app/models/common/coach-id-params';
import { Coach } from 'src/app/models/data/coach';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CoachService } from 'src/app/services/data/coach.service';

@Component({
  selector: 'app-coach-dialog',
  templateUrl: './coach-dialog.component.html',
  styleUrls: ['./coach-dialog.component.scss']
})
export class CoachDialogComponent implements OnInit {

  coach: Coach[] = [];
  coachDataSource: MatTableDataSource<Coach> = new MatTableDataSource(this.coach);
  coachColumns: string[] = ['coachName', 'joinDate', 'email', 'phone', 'address'];

  constructor(
    private coachService: CoachService,
    private notifyService: NotifyService,
    @Inject(MAT_DIALOG_DATA) public data: CoachIdParams
  ) { }

  ngOnInit(): void {
    const selectionPanelId = this.data?.id;

    if (selectionPanelId !== undefined && selectionPanelId !== null) {
      this.coachService.getCoachesBySelectionPanelId(selectionPanelId)
        .subscribe({
          next: r => {
            this.coach = r;
            console.log(this.coach);
            this.coachDataSource.data = this.coach;
          },
          error: err => {
            this.notifyService.message(`Failed to load Coach info ${selectionPanelId}`);
            console.log(err.message || err);
          }
        });

    } else {
      console.error('Invalid selectionPanelId:', selectionPanelId);
    }
  }
}  