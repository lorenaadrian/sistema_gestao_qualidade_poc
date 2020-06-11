import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NaoConformidadeListComponent } from './nao-conformidade-list.component';

describe('NaoConformidadeListComponent', () => {
  let component: NaoConformidadeListComponent;
  let fixture: ComponentFixture<NaoConformidadeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NaoConformidadeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NaoConformidadeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
