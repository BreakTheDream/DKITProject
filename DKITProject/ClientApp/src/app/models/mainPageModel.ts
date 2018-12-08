import { NewPreview } from './new';
import { SpecialtyPreview } from './specialty';
import { WorkshopPreview } from './workshop';
import { AdditionalEducationPreview } from './additionalEducation';
import { Partner } from './partner';
import { Certificate } from './certificate'; 

export class MainPageModel {
    constructor(
        public news: NewPreview[],
        public specialties: SpecialtyPreview[],
        public workshops: WorkshopPreview[],
        public additionalEducations: AdditionalEducationPreview[],
        public partners: Partner[],
        public certificates: Certificate[]
    ){}
}