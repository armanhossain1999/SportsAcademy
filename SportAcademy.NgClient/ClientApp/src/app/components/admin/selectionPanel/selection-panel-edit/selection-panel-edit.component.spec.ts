import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionPanelEditComponent } from './selection-panel-edit.component';

describe('SelectionPanelEditComponent', () => {
  let component: SelectionPanelEditComponent;
  let fixture: ComponentFixture<SelectionPanelEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectionPanelEditComponent]
    });
    fixture = TestBed.createComponent(SelectionPanelEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
