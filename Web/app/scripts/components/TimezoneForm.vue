<template>
    <div v-if="isReady">
        <h3>Timezone</h3>
        <div class="timezone-info">
            <p v-show="showForm">
                <select :value="value" v-on:input="updateValue">
                    <option v-for="t in timezones" :value="t.id" :key="t.id">{{t.id}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                {{value}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Timezone } from '@/types/Timezone';
    import { Component, Mixins, Prop } from 'vue-property-decorator';
    import { StoreMixin} from '../StoreMixin';
    
    @Component
    export default class TimezoneForm extends Mixins(
        StoreMixin
    ) {
        @Prop() value!: string;
        @Prop() readonly timezones!: Timezone[];
        showForm = false;
        
        updateValue(event: any){
            this.close();
            this.$emit('input', event.target.value);
        }

        get isReady(){
            return this.timezones.length;
        }

        open() {
            this.showForm = true;
        }

        close() {
            this.showForm = false;
        }
    }
</script>