import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerDialogComponent } from './manager-dialog.component';

describe('ManagerDialogComponent', () => {
  let component: ManagerDialogComponent;
  let fixture: ComponentFixture<ManagerDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManagerDialogComponent]
    });
    fixture = TestBed.createComponent(ManagerDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
