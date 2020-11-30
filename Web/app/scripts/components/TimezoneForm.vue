<template>
    <div>
        <h3>Timezone</h3>
        <div class="timezone-info">
            <p v-show="showForm">
                <select v-model.number="timezone">
                    <option v-for="t in timezones" :value="t.id" :key="t.id">{{t.id}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                {{timezone}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Mixins } from 'vue-property-decorator';
    import { StoreMixin} from '../StoreMixin';
    
    @Component
    export default class TimezoneForm extends Mixins(
        StoreMixin
    ) {
        showForm = false;

        get timezoneId() {
            return this.$_timezoneId;
        }
        
        set timezoneId(value) {
            this.$_selectTimezone(value);
            this.close();
        }

        get timezones(){
            return this.$_timezones;
        }

        open() {
            this.showForm = true;
        }

        close() {
            this.showForm = false;
        }
    }
</script>