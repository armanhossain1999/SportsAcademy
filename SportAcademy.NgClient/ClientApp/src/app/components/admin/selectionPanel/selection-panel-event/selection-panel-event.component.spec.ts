import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionPanelEventComponent } from './selection-panel-event.component';

describe('SelectionPanelEventComponent', () => {
  let component: SelectionPanelEventComponent;
  let fixture: ComponentFixture<SelectionPanelEventComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectionPanelEventComponent]
    });
    fixture = TestBed.createComponent(SelectionPanelEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
