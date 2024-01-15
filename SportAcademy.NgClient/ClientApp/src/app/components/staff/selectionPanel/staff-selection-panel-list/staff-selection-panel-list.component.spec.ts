import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffSelectionPanelListComponent } from './staff-selection-panel-list.component';

describe('StaffSelectionPanelListComponent', () => {
  let component: StaffSelectionPanelListComponent;
  let fixture: ComponentFixture<StaffSelectionPanelListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StaffSelectionPanelListComponent]
    });
    fixture = TestBed.createComponent(StaffSelectionPanelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
