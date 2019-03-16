import { NewPreview } from './new';
import { SpecialityPreviewModel } from './speciality';
import { Partner } from './partner';
import { Certificate } from './certificate'; 

export class MainPageModel {
    constructor(
        public news: NewPreview[],
        public specialties: SpecialityPreviewModel[],
        public partners: Partner[],
        public certificates: Certificate[]
    ){}
}